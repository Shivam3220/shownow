import React, { act, useEffect, useState } from "react";
import { useUserLoginProvider } from "../hooks/context/userContext";
import { useNavigate } from "react-router-dom";

type RegisterForm = {
	name: string;
	email: string;
	password: string;
};

const Login = () => {
	const [loginScreen, setLoginScreen] = useState("login");
  const navigate = useNavigate();
  const { state } = useUserLoginProvider();

  useEffect(() => {
    if(state.isLoggedIn)
    {
      navigate("/")
    }
  }, [navigate, state])
  

	let Component = loginScreen === "login" ? SignIn : Register;

	return (
		<div className="w-full h-[100vh] flex items-center justify-center bg-yellow-500">
			<div className="w-1/2 h-1/2">
				<Component setLoginScreen={setLoginScreen} />
			</div>
		</div>
	);
};

type SignInForm = {
	email: string;
	password: string;
};

const SignIn = ({
	setLoginScreen,
}: {
	setLoginScreen: React.Dispatch<React.SetStateAction<string>>;
}) => {
	const [form, setForm] = useState<SignInForm>({
		email: "",
		password: "",
	});

	const { actions } = useUserLoginProvider();

	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;

		setForm((prev) => ({
			...prev,
			[name]: value,
		}));
	};

	const handleSubmit = async (e: React.FormEvent) => {
		e.preventDefault();

		try {
			const res = await fetch("https://localhost:7084/api/v1/User/signIn", {
				method: "POST",
				headers: {
					"Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*"
				},
				body: JSON.stringify(form),
			});

			if (!res.ok) {
				console.error("Invalid credentials");
			}

			const data = await res.json();
      actions.signIn(data.uid)

			console.log("Logged in:", data);

			// handle token / redirect here
		} catch (error) {
			console.error(error);
		}
	};

	return (
		<form
			onSubmit={handleSubmit}
			className="w-full bg-white h-full max-w-md p-8 rounded-2xl shadow-lg space-y-6"
		>
			<h2 className="text-2xl font-bold text-center text-gray-800">Sign In</h2>

			<div>
				<label className="block text-sm font-medium text-gray-600 mb-1">
					Email
				</label>
				<input
					name="email"
					type="email"
					value={form.email}
					onChange={handleChange}
					placeholder="you@example.com"
					className="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
				/>
			</div>

			<div>
				<label className="block text-sm font-medium text-gray-600 mb-1">
					Password
				</label>
				<input
					name="password"
					type="password"
					value={form.password}
					onChange={handleChange}
					placeholder="••••••••"
					className="w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"
				/>
			</div>

			<button
				type="submit"
				className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition"
			>
				Sign In
			</button>

			<button
				type="button"
				onClick={() => setLoginScreen("Register")}
				className="w-full bg-green-600 text-white py-2 rounded-lg hover:bg-green-700 transition"
			>
				Create New Account
			</button>
		</form>
	);
};

const Register = ({
	setLoginScreen,
}: {
	setLoginScreen: React.Dispatch<React.SetStateAction<string>>;
}) => {
	const [form, setForm] = useState({
		name: "",
		email: "",
		password: "",
	});

	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setForm((prev) => ({ ...prev, [name]: value }));
	};

	const handleSubmit = async (e: React.FormEvent) => {
		e.preventDefault();

		try {
			await fetch("https://localhost:7084/api/v1/User/register", {
				method: "POST",
				headers: { "Content-Type": "application/json",  "Access-Control-Allow-Origin": "*" },
				body: JSON.stringify(form),
			});

			setLoginScreen("login");
		} catch (err) {
			console.error(err);
		}
	};

	return (
		<form
			onSubmit={handleSubmit}
			className="w-full max-w-md bg-white p-8 rounded-2xl shadow-lg space-y-6"
		>
			<h2 className="text-2xl font-bold text-center text-gray-800">
				Create Account
			</h2>

			<input
				name="name"
				placeholder="John Doe"
				onChange={handleChange}
				value={form.name}
				className="w-full px-4 py-2 border rounded-lg"
			/>

			<input
				name="email"
				type="email"
				placeholder="you@example.com"
				onChange={handleChange}
				value={form.email}
				className="w-full px-4 py-2 border rounded-lg"
			/>

			<input
				name="password"
				type="password"
				placeholder="••••••••"
				onChange={handleChange}
				value={form.password}
				className="w-full px-4 py-2 border rounded-lg"
			/>

			<button
				type="submit"
				className="w-full bg-green-600 text-white py-2 rounded-lg"
			>
				Register
			</button>

			<button
				type="button"
				onClick={() => setLoginScreen("login")}
				className="w-full bg-blue-600 text-white py-2 rounded-lg"
			>
				Already Login
			</button>
		</form>
	);
};

export default Login;
