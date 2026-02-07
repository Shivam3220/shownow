import React, { useEffect, useState } from "react";
import { useUserLoginProvider } from "../hooks/context/userContext";

type OrderItem = {
	// Customize if you want to render individual items later
	// For now, it's empty in your example, so we can skip or expand later
};

type Order = {
	orderUid: string;
	status: string;
	totalItem: number;
	subTotal: number;
	coupon: string | null;
	discount: number;
	items: OrderItem[];
};

export const Orders = () => {
	const [orders, setOrders] = useState<Order[]>([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState<string | null>(null);
	const { state } = useUserLoginProvider();

	useEffect(() => {
		const fetchOrders = async () => {
			try {
				const res = await fetch(
					`https://localhost:7084/api/v1/Order/user/${state.userId}`,
				); // Replace with your API endpoint
				if (!res.ok) throw new Error("Failed to fetch orders");
				const data: Order[] = await res.json();
				setOrders(data);
			} catch (err) {
				setError((err as Error).message);
			} finally {
				setLoading(false);
			}
		};

		fetchOrders();
	}, []);

	if (loading) return <p>Loading orders...</p>;
	if (error) return <p>Error: {error}</p>;

	return (
		<div className="max-w-3xl mx-auto p-6 bg-white rounded shadow">
			<h1 className="text-2xl font-semibold mb-4">Your Orders</h1>
			{orders.length === 0 ? (
				<p>No orders found.</p>
			) : (
				<ul className="space-y-4">
					{orders.map(
						({ orderUid, status, totalItem, subTotal, coupon, discount }) => (
							<li
								key={orderUid}
								className="border p-4 rounded hover:shadow-md transition"
							>
								<p>
									<strong>Order ID:</strong> {orderUid}
								</p>
								<p>
									<strong>Status:</strong> {status}
								</p>
								<p>
									<strong>Items:</strong> {totalItem}
								</p>
								<p>
									<strong>Subtotal:</strong> ${subTotal.toFixed(2)}
								</p>
								{coupon && (
									<p>
										<strong>Coupon:</strong> {coupon}
									</p>
								)}
								<p>
									<strong>Discount:</strong> ${discount.toFixed(2)}
								</p>
								<p>
									<strong>Total:</strong> ${(subTotal - discount).toFixed(2)}
								</p>
							</li>
						),
					)}
				</ul>
			)}
		</div>
	);
};
