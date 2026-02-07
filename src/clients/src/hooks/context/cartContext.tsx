import { createContext, useContext, useEffect, useState } from "react";

type CartItem = {
	productUid: string;
	productName: string;
	price: number;
	quantity: number;
};

type CartState = {
	cartUid?: string;
	status?: string;
	totalItem: number;
	subTotal: number;
	coupon?: string | null;
	discount: number;
	items: CartItem[];
};

type CartContextType = {
	state: CartState;
	actions: {
		addToCart: (productId: string, quantity: number) => Promise<void>;
		applyCoupon: () => Promise<void>;
		checkout: (userId: string) => Promise<void>;
	};
};

const CartContext = createContext<CartContextType>({
	state: {
		items: [],
		coupon: undefined,
		discount: 0,
		totalItem: 0,
		subTotal: 0,
	},
	actions: {
		addToCart: async () => {},
		applyCoupon: async () => {},
		checkout: async () => {},
	},
});

export const useCart = () => useContext(CartContext);

export const CartProvider = ({
	children,
	userId,
}: {
	children: React.ReactNode;
	userId: string;
}) => {
	const [state, setState] = useState<CartState>({
		items: [],
		discount: 0,
		totalItem: 0,
		subTotal: 0,
	});

	// Load active cart for the user on startup
	useEffect(() => {
		const fetchCartForUser = async () => {
			try {
				// 1️⃣ Fetch user data (assuming your API returns cartUid or userId)
				const userRes = await fetch(
					`https://localhost:7084/api/v1/Cart/user/${userId}/cart`,
				);
				const userData = await userRes.json();
				const cartUid = userData.cartUid; // or whatever your API returns
				let cartData;

				if (cartUid) {
					// 2️⃣ Fetch cart using cartUid
					const cartRes = await fetch(
						`https://localhost:7084/api/v1/Cart/${cartUid}`,
					);
					if (cartRes.status === 404) {
						cartData = await createNewCart();
					} else if (!cartRes.ok) {
						throw new Error("Failed to fetch cart");
					} else {
						cartData = await cartRes.json();
					}
				} else {
					// If user has no cartUid, create a new cart
					cartData = await createNewCart();
				}

				// 3️⃣ Map items if necessary
				const mappedItems: CartItem[] = cartData.items.map((item: any) => ({
					productUid: item.productUid,
					productName: item.productName,
					price: item.price,
					quantity: item.quantity,
				}));

				// 4️⃣ Set full cart state
				setState({
					cartUid: cartData.cartUid,
					status: cartData.status,
					totalItem: cartData.totalItem,
					subTotal: cartData.subTotal,
					coupon: cartData.coupon,
					discount: cartData.discount,
					items: mappedItems,
				});
			} catch (err) {
				console.error(err);
			}
		};

		if (userId) fetchCartForUser();
	}, [userId]);

	// Add product to cart API call
	const createNewCart = async () => {
		try {
			const res = await fetch(
				`https://localhost:7084/api/v1/Cart/user/${userId}/create-cart`,
				{
					method: "POST",
					headers: { "Content-Type": "application/json" },
				},
			);

			if (!res.ok) throw new Error("Failed to create cart");

			const data = await res.json();

			// Map API items to CartItem type if needed
			const mappedItems: CartItem[] = data.items.map((item: any) => ({
				productId: item.productId,
				quantity: item.quantity,
			}));

			setState({
				cartUid: data.cartUid,
				status: data.status,
				totalItem: data.totalItem,
				subTotal: data.subTotal,
				coupon: data.coupon,
				discount: data.discount,
				items: mappedItems,
			});
		} catch (err) {
			console.error(err);
		}
	};

	const addToCart = async (productId: string, quantity: number) => {
		try {
			const res = await fetch(`https://localhost:7084/api/v1/Cart/item`, {
				method: "POST",
				headers: { "Content-Type": "application/json" },
				body: JSON.stringify({
					cartUid: state.cartUid,
					productUid: productId,
					quantity,
				}),
			});

			if (!res.ok) throw new Error("Failed to add to cart");
			const updatedCart = await res.json();

			console.log("addto cart", updatedCart);
			alert("Item Added to cart");
			// 3️⃣ Map items if necessary
			const mappedItems: CartItem[] = updatedCart.items.map((item: any) => ({
				productUid: item.productUid,
				productName: item.productName,
				price: item.price,
				quantity: item.quantity,
			}));

			// 4️⃣ Set full cart state
			setState({
				cartUid: updatedCart.cartUid,
				status: updatedCart.status,
				totalItem: updatedCart.totalItem,
				subTotal: updatedCart.subTotal,
				coupon: updatedCart.coupon,
				discount: updatedCart.discount,
				items: mappedItems,
			});
		} catch (err) {
			console.error(err);
		}
	};

	// Apply coupon API call
	const applyCoupon = async () => {
		try {
			const res = await fetch(
				`https://localhost:7084/api/v1/Cart/${state.cartUid}/apply-coupon`,
				{
					method: "POST",
					headers: { "Content-Type": "application/json" },
				},
			);
			debugger;

			if (!res.ok) throw new Error("Failed to apply coupon");

			const data = await res.json();

			// Map API items to CartItem type if needed

			setState({
				...state,
				cartUid: data.cartUid,
				status: data.status,
				totalItem: data.totalItem,
				subTotal: data.subTotal,
				coupon: data.coupon,
				discount: data.discount,
			});
		} catch (err) {
			console.error(err);
		}
	};

	// Checkout API call
	const checkout = async (userId: string) => {
		try {
			const res = await fetch(
				`https://localhost:7084/api/v1/Cart/${userId}/checkout`,
				{
					method: "POST",
					headers: { "Content-Type": "application/json" },
					body: JSON.stringify({ userId, coupon: state.coupon }),
				},
			);

			if (!res.ok) throw new Error("Checkout failed");

			const order = await res.json();
			console.log("Order placed:", order);
			const cartData = await createNewCart();

			// Clear local cart state
		} catch (err) {
			console.error(err);
		}
	};

	return (
		<CartContext.Provider
			value={{ state, actions: { addToCart, applyCoupon, checkout } }}
		>
			{children}
		</CartContext.Provider>
	);
};
