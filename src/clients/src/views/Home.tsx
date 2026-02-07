import React, { useEffect } from "react";
import { useUserLoginProvider } from "../hooks/context/userContext";
import { useNavigate } from "react-router-dom";

export const Home = () => {
	const { state } = useUserLoginProvider();
	const navigate = useNavigate();

	useEffect(() => {
		if (!state.isLoggedIn) {
			navigate("/login");
		}
	}, [state.isLoggedIn, navigate]);

	return <div>Home</div>;
};
