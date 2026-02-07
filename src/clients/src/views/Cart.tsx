import React, { useState } from "react";
import { useCart } from "../hooks/context/cartContext";
import { useUserLoginProvider } from "../hooks/context/userContext";

export const Cart = () => {
	const { state, actions } = useCart();
	const data = useUserLoginProvider();
	const { items, coupon, discount, subTotal } = state;

	// Local state to hold updated quantities before sending API call
	const [quantities, setQuantities] = useState(() =>
		items.reduce(
			(acc, item) => {
				acc[item.productUid] = item.quantity;
				return acc;
			},
			{} as Record<string, number>,
		),
	);

	// Handle quantity change locally
	const handleQuantityChange = (productUid: string, newQty: number) => {
    debugger;
		if (newQty < 1) return; // prevent less than 1
		setQuantities((prev) => ({ ...prev, [productUid]: newQty }));
	};

	// When user leaves input or presses update button, call context action to update
	// Assuming your context has addToCart or updateCartQuantity method for updating quantity
	// Since you said only addToCart is implemented, we'll call addToCart with new quantity difference

	const handleUpdateQuantity = (productUid: string) => {
    debugger
		const currentItem = items.find((i) => i.productUid === productUid);
		if (!currentItem) return;
		const currentQty = currentItem.quantity;
		const newQty = quantities[productUid];

		if (newQty > 0) {
			// Add the difference
			actions.addToCart(currentItem.productUid, newQty);
		} else {
			// You don't have a remove or update method.
			// So, for now, ignore reducing quantity (or extend context with update method)
			alert("Negative quantity is not allowed");
		}
	};

	const totalPrice = subTotal - discount;

	return (
		<div className="max-w-4xl mx-auto p-6 bg-white rounded-lg shadow-md">
			<h1 className="text-3xl font-semibold mb-6">Your Cart</h1>

			{items.length === 0 ? (
				<p className="text-gray-600">Your cart is empty.</p>
			) : (
				<>
					<div className="space-y-4">
						{items.map(({ productUid, productName, price, quantity }) => (
							<div
								key={productUid}
								className="flex items-center justify-between border-b pb-4"
							>
								<div>
									<h2 className="text-xl font-medium">{productName}</h2>
									<p className="text-gray-600">${price} each</p>
								</div>
								<div className="flex items-center space-x-2">
									<input
										type="number"
										min={1}
										value={quantities[productUid] || quantity}
										onChange={(e) =>
											handleQuantityChange(productUid, +e.target.value)
										}
										className="w-16 px-2 py-1 border rounded text-center"
									/>
									<button
										onClick={() => handleUpdateQuantity(productUid)}
										className="bg-blue-600 text-white px-3 py-1 rounded hover:bg-blue-700"
									>
										Update
									</button>
								</div>
								<div className="font-semibold">${price * quantity}</div>
							</div>
						))}
					</div>

					<div className="mt-6 border-t pt-4">
						<p className="text-lg">
							Subtotal: <span className="font-semibold">${subTotal}</span>
						</p>
						{coupon && (
							<p className="text-lg">
								Coupon (<span className="font-semibold">{coupon}</span>): -$
								{discount}
							</p>
						)}
						<p className="text-2xl font-bold mt-2">
							Total: <span>${totalPrice}</span>
						</p>
					</div>

					<button
						onClick={() => actions.checkout(data.state.userId!)}
						className="mt-6 w-full bg-green-600 text-white py-3 rounded-lg hover:bg-green-700 transition"
					>
						Checkout
					</button>

					<button
						onClick={() => actions.applyCoupon()}
						className="mt-6 w-full bg-green-600 text-white py-3 rounded-lg hover:bg-green-700 transition"
					>
						Apply Coupon
					</button>
				</>
			)}
		</div>
	);
};
