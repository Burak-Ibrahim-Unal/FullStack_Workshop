import { Button, ButtonGroup, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { decrement, increment } from "./counterSlice";

export default function ContactPage() {
  const { data, title } = useAppSelector(state => state.counter);
  const dispatch = useAppDispatch();

  return (
    <>
      <Typography variant="h2">Contact Page Test</Typography>
      <Typography variant="h4">
        {title} - data is {data}
      </Typography>
      <ButtonGroup>
        <Button
          onClick={() => dispatch(decrement(1))}
          variant="contained"
          color="error"
        >
          Decrement
        </Button>
        <Button
          onClick={() => dispatch(increment(1))}
          variant="contained"
          color="primary"
        >
          Increment
        </Button>
        <Button
          onClick={() => dispatch(increment(5))}
          variant="contained"
          color="secondary"
        >
          Increment 5
        </Button>
      </ButtonGroup>
    </>
  );
}
