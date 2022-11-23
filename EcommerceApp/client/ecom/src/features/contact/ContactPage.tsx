import { Button, ButtonGroup, Typography } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import {
  CounterState,
  INCREMENTCOUNTER,
  DECREMENTCOUNTER,
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
          onClick={() => dispatch({ type: DECREMENTCOUNTER })}
          variant="contained"
          color="error"
        >
          Decrement
        </Button>
        <Button
          onClick={() => dispatch({ type: INCREMENTCOUNTER })}
          variant="contained"
          color="primary"
        >
          Increment
        </Button>
      </ButtonGroup>
    </>
  );
}
