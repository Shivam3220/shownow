import React, { useEffect } from "react";
import { useUserLoginProvider } from "../hooks/context/userContext";
import { Route, Routes, useNavigate } from "react-router-dom";
import { Navbar } from "../components/Navbar";
import { Orders } from "./Orders";
import { Cart } from "./Cart";
import { Products } from "./Products";

export const Home = () => {
	const { state } = useUserLoginProvider();
	const navigate = useNavigate();

	useEffect(() => {
		if (!state.isLoggedIn) {
			navigate("/login");
		}
	}, [state.isLoggedIn, navigate]);

	return (
		<div>
			<Navbar />
			<Routes>
				<Route path="orders" element={<Orders />} />
				<Route path="cart" element={<Cart />} />
				<Route path="/" element={<Products />} />
			</Routes>
		</div>
	);
};
