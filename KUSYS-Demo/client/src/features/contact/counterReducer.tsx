export const INCREMENTCOUNTER = "INCREMENTCOUNTER"; // action type
export const DECREMENTCOUNTER = "DECREMENTCOUNTER"; // action type

export interface CounterState {
  data: number;
  title: string;
}

const initialState: CounterState = {
  data: 33,
  title: "Redux Counter Redux/Toolkit",
};

export function increment(amount = 1) { // action creator
  return {
    type: INCREMENTCOUNTER,
    payload: amount
  };
}

export function decrement(amount = 1) { // action creator
  return {
    type: DECREMENTCOUNTER,
    payload: amount
  };
}

export default function counterReducer(state = initialState, action: any) {
  switch (action.type) {
    case INCREMENTCOUNTER:
      return {
        ...state,
        data: state.data + action.payload,
      };
    case DECREMENTCOUNTER:
      return {
        ...state,
        data: state.data - action.payload,
      };

    default:
      return state;
  }
}
