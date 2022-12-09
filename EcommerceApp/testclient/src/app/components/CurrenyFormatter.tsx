import { DataTypeProvider } from "@devexpress/dx-react-grid";
import { useState } from "react";

// TL Option
const CurrencyFormatterTL = ({ value }: any) => (
  <b style={{ color: "darkblue" }}>
    {value.toLocaleString("tr-TR", { style: "currency", currency: "TL" })}
  </b>
);

// USD Option
const CurrencyFormatterUSD = ({ value }: any) => (
    <b style={{ color: "darkblue" }}>
      {value.toLocaleString("us-US", { style: "currency", currency: "USD" })}
    </b>
  );

const CurrencyTypeProvider = (props: any) => (
  <DataTypeProvider formatterComponent={CurrencyFormatterTL} {...props} />
);

export default function CurrencyFormatter() {
  const [currencyColumns] = useState(["price"]);

  return <CurrencyTypeProvider for={currencyColumns} />;
}
