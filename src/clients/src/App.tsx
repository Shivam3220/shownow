import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Login from "./views/login";
import { Home } from "./views/Home";
import { Products } from "./views/Products";
import { CartProvider } from "./hooks/context/cartContext";
import { useUserLoginProvider } from "./hooks/context/userContext";

function App() {
	const { state } = useUserLoginProvider();
	return (
		<div className="App">
			<CartProvider userId={state.userId!}>
				<BrowserRouter>
					<Routes>
						<Route path="/login" element={<Login />} />
						<Route path="/*" element={<Home />} />
					</Routes>
				</BrowserRouter>
			</CartProvider>
		</div>
	);
}

export default App;
