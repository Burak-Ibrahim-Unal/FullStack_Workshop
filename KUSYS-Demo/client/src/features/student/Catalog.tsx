import { FormLabel, Grid, Paper } from "@mui/material";
import { useEffect } from "react";
import AppPagination from "../../app/components/AppPagination";
import CheckboxButtons from "../../app/components/CheckboxButtons";
import RadioButtonGroup from "../../app/components/RadioButtonGroup";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import {
  fetchFilters,
  fetchStudentsAsync,
  studentSelectors,
  setPageNumber,
  setStudentParams,
} from "./catalogSlice";
import StudentList from "./StudentList";
import StudentSearch from "./StudentSearch";

const sortOptions = [
  { value: "firstname", label: "Alphabetical" },
  { value: "lastname", label: "Alphabetical" },
  { value: "birthdate", label: "Price - High to Low" },
  { value: "birthdate", label: "Price - Low to High" },
];

export default function Catalog() {
  const students = useAppSelector(studentSelectors.selectAll);
  const {
    studentsLoaded,
    filtersLoaded,
    courses,
    studentParams,
    metaData,
  } = useAppSelector((state) => state.catalog);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!studentsLoaded) dispatch(fetchStudentsAsync());
  }, [studentsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [dispatch, filtersLoaded]);

  if (!filtersLoaded) return <LoadingComponent loadingMessage="Loading Students..." />;

  return (
    <Grid container columnSpacing={4}>
      <Grid item xs={3}>
        <Paper sx={{ mb: 2, mt: -3, mr: 3 }}>
          <StudentSearch />
        </Paper>
        <Paper sx={{ mb: 2, mr: 3, p: 2 }}>
          <RadioButtonGroup
            selectedValue={studentParams.orderBy}
            options={sortOptions}
            onChange={(e) =>
              dispatch(
                setStudentParams({
                  orderBy: e.target.value,
                })
              )
            }
          />
        </Paper>
        <Paper sx={{ mb: 2, mr: 3, p: 2 }}>
          <FormLabel id="demo-radio-buttons-group-label">Brand</FormLabel>
          <CheckboxButtons
            items={courses}
            checked={studentParams.courses}
            onChange={(items: string[]) =>
              dispatch(setStudentParams({ courses: items }))
            }
          />
        </Paper>
      </Grid>
      <Grid item xs={9}>
        <StudentList students={students} />
      </Grid>
      <Grid item xs={3} />
      <Grid item xs={9} sx={{ mb: 3 }}>
        {metaData && (
          <AppPagination
            metaData={metaData}
            onPageChange={(page: number) =>
              dispatch(setPageNumber({ pageNumber: page }))
            }
          />
        )}
      </Grid>
    </Grid>
  );
}
