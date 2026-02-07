import { useEffect, useState } from "react";
import { useCart } from "../hooks/context/cartContext";
import { useUserLoginProvider } from "../hooks/context/userContext";

type Product = {
  id: number;
  uid: string;
  name: string;
  description: string;
  image: string;
  price: number;
  stock: number;
};

export const Products = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [quantity, setQuantity] = useState<Record<string, number>>({});
  const [loading, setLoading] = useState(false);
  const { actions } = useCart();

  // 🔹 Fetch products
  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const res = await fetch("https://localhost:7084/api/v1/Product");
        const data: Product[] = await res.json();
        setProducts(data);
      } catch (err) {
        console.error(err);
      }
    };

    fetchProducts();
  }, []);


  return (
    <div className="p-6 grid gap-6 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
      {products.map(product => (
        <div
          key={product.id}
          className="bg-white rounded-xl shadow-md overflow-hidden flex flex-col"
        >
          <img
            src={product.image}
            alt={product.name}
            className="h-48 w-full object-cover"
          />

          <div className="p-4 flex flex-col flex-1">
            <h3 className="text-lg font-bold text-gray-800">
              {product.name}
            </h3>

            <p className="text-gray-600 text-sm mt-1 flex-1">
              {product.description}
            </p>

            <div className="mt-3 text-lg font-semibold text-blue-600">
              ${product.price}
            </div>

            <div className="mt-4 flex items-center gap-3">
              <input
                type="number"
                min={1}
                max={product.stock}
                value={quantity[product.uid] || 1}
                onChange={e =>{
                  setQuantity(prev => ({
                    ...prev,
                    [product.uid]: Number(e.target.value),
                  }))}
                }
                className="w-20 px-2 py-1 border rounded-lg"
              />

              <button
                disabled={loading}
                onClick={() => actions.addToCart(product.uid, quantity[product.uid] || 1)}
                className="flex-1 bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition disabled:opacity-50"
              >
                Add to Cart
              </button>
            </div>

            <p className="text-xs text-gray-500 mt-2">
              In stock: {product.stock}
            </p>
          </div>
        </div>
      ))}
    </div>
  );
};
