import { debounce, TextField } from "@mui/material";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { useAppSelector } from "../../app/store/configureStore";
import { setStudentParams } from "./catalogSlice";

export default function StudentSearch() {
  const { studentParams } = useAppSelector((state) => state.catalog);
  const [searchTerm, setSearchTerm] = useState(studentParams.searchTerm);
  const dispatch = useDispatch();

  const debouncedSearch = debounce((event: any) => {
    dispatch(setStudentParams({ searchTerm: event.target.value }));
  }, 1500);

  return (
    <TextField
      label="Search Student"
      variant="outlined"
      fullWidth
      value={searchTerm || ""}
      onChange={(event: any) => {
        setSearchTerm(event.target.value);
        debouncedSearch(event);
      }}
    />
  );
}
