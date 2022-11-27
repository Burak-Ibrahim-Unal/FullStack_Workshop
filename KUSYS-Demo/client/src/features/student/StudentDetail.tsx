import { LoadingButton } from "@mui/lab";
import {
  Divider,
  Grid,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchStudentAsync, studentSelectors } from "./catalogSlice";

export default function StudentDetail() {
  const dispatch = useAppDispatch();
  const { id } = useParams();
  const student = useAppSelector((state) =>
    studentSelectors.selectById(state, id!)
  );
  const { status: studentStatus } = useAppSelector((state) => state.catalog);
  const [quantity, setQuantity] = useState(0);

  useEffect(() => {
    if (!student) dispatch(fetchStudentAsync(parseInt(id!)));
  }, [id, dispatch, student]);

  function handleInputChange(event: any) {
    if (event.target.value >= 0) setQuantity(parseInt(event.target.value));
  }

  if (studentStatus.includes("pending")) return <LoadingComponent />;

  if (!student) return <NotFound />;

  return (
    <Grid container spacing={6}>
      <Grid item xs={6}>
        <img
          src="../../../public/images/student.jpg"
          alt={student.firstname}
          style={{ width: "100%" }}
        />
      </Grid>
      <Grid item xs={6}>
        <Typography variant="h3">
          {student.firstname} + {student.lastname}
        </Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography variant="h4" color="secondary">
          ${student.birthdate}
        </Typography>
        <TableContainer>
          <Table>
            <TableBody>
              <TableRow>
                <TableCell>First Name</TableCell>
                <TableCell>{student.firstname}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Last Name</TableCell>
                <TableCell>{student.lastname}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Birthday</TableCell>
                <TableCell>{student.birthdate}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <TextField
              onChange={handleInputChange}
              variant="outlined"
              type="number"
              label="Quantity in Card"
              fullWidth
              value={quantity}
            />
          </Grid>
          <Grid item xs={6}></Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
