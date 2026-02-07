import { createContext, useContext, useState } from "react";

type InitialUserStateType = {
	state: {
		userId?: string | null;
		isLoggedIn: boolean;
	};
	actions: {
		signIn: (userId: string) => void;
		signOut: () => void;
	};
};
const UserContext = createContext<InitialUserStateType>({
	state: { isLoggedIn: false },
	actions:{
        signOut: () => {},
        signIn: (userId) => {}
    },
});

export const useUserLoginProvider = () => useContext(UserContext);

export const UserLoginProvider = ({
	children,
	initialState,
}: {
	children: React.ReactNode;
	initialState: InitialUserStateType["state"];
}) => {
	const [state, setState] =
		useState<InitialUserStateType["state"]>(initialState);

	const signOut = () => {
        setState({isLoggedIn: false, userId: null})
    }

	const signIn = (userId: string) => {
        setState({isLoggedIn: true, userId: userId})
    }

	return (
		<UserContext.Provider
			value={{
				state: state,
				actions: {signOut: signOut, signIn: signIn},
			}}
		>
			{children}
		</UserContext.Provider>
	);
};
