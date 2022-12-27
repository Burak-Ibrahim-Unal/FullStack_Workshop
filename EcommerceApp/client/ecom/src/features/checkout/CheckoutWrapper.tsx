import { Elements } from "@stripe/react-stripe-js";
import { loadStripe } from "@stripe/stripe-js";
import CheckoutPage from "./CheckoutPage";

const stripePromise = loadStripe(
  "pk_test_51MJYvOI6OgkxeOAZm9p6cMtFELaZJ3rYPLVwVA32slaXybyArT1699l1jUPewtizOGFlszypWelfREkN7iUn4bPb00QcxFGOBe"
);

export default function CheckoutWrapper() {
  return (
    <Elements stripe={stripePromise}>
      <CheckoutPage />
    </Elements>
  );
}
