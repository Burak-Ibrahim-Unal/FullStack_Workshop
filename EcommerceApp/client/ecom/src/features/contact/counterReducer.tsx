export const INCREMENTCOUNTER = "INCREMENTCOUNTER";
export const DECREMENTCOUNTER = "DECREMENTCOUNTER";

export interface CounterState {
  data: number;
  title: string;
}

const initialState: CounterState = {
  data: 33,
  title: "Redux Counter",
};

export default function counterReducer(state = initialState, action: any) {
  switch (action.type) {
    case INCREMENTCOUNTER:
      return {
        ...state,
        data: state.data + 1,
      };
    case DECREMENTCOUNTER:
      return {
        ...state,
        data: state.data - 1,
      };

    default:
      return state;
  }
  return state;
}
