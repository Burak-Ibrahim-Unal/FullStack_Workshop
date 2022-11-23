import { Button, ButtonGroup, Typography } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  CounterState,
  DECREMENTCOUNTER,
  increment,
  decrement,
} from "./counterReducer";

export default function ContactPage() {
  const { data, title } = useSelector((state: CounterState) => state);
  const dispatch = useDispatch();

  return (
    <>
      <Typography variant="h2">Contact Page Test</Typography>
      <Typography variant="h4">
        {title} - data is {data}
      </Typography>
      <ButtonGroup>
        <Button
          onClick={() => dispatch(decrement())}
          variant="contained"
          color="error"
        >
          Decrement
        </Button>
        <Button
          onClick={() => dispatch(increment())}
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
