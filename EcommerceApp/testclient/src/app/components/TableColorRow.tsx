import { alpha, styled } from "@mui/material/styles";
import { Table } from "@devexpress/dx-react-grid-material-ui";

const PREFIX = "Ficommerce_TableColor";
const classes = {
  tableStriped: `${PREFIX}-tableStriped`,
};
const StyledTable = styled(Table.Table)(({ theme }) => ({
  [`&.${classes.tableStriped}`]: {
    "& tbody tr:nth-of-type(odd)": {
      backgroundColor: alpha(theme.palette.primary.main, 0.15),
    },
  },
}));

export default function TableColorRowComponent(props: any) {
    return(
          <StyledTable {...props} className={classes.tableStriped} />
    );
}
