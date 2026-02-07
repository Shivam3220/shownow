import { Link } from "react-router-dom";
import { useUserLoginProvider } from "../hooks/context/userContext";

export const Navbar = () => {
	const { actions } = useUserLoginProvider();
	return (
		<nav className="sticky top-0 z-50 w-full bg-white shadow-md px-6 py-4 flex items-center justify-between">
			{/* Logo / App Name */}
			<Link
				to="/"
				className="text-xl font-bold text-gray-800 hover:text-blue-600 transition"
			>
				Show Now
			</Link>

			{/* Navigation */}
			<div className="flex items-center gap-6">
				<Link
					to="/orders"
					className="text-gray-600 hover:text-blue-600 transition font-medium"
				>
					Orders
				</Link>

				<Link
					to="/cart"
					className="text-gray-600 hover:text-blue-600 transition font-medium"
				>
					Cart
				</Link>

				<button
					onClick={() => {
						// logout logic here
            actions.signOut()
						console.log("logout");
					}}
					className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600 transition"
				>
					Logout
				</button>
			</div>
		</nav>
	);
};
