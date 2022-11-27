import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { useNavigate, useLocation } from "react-router-dom";

export default function ServerError() {
  const navigate = useNavigate(); // router 5 const history=useHistory()
  const { state } = useLocation();

  return (
    <Container component={Paper}>
      {state?.error ? (
        <>
          <Typography variant="h3" gutterBottom color="error">
            Server Error - {state.error.title}
          </Typography>
          <Divider />
          <Typography variant="h5" gutterBottom>
            {state.error.detail || "internal server error"}
          </Typography>
        </>
      ) : (
        <Typography variant="h5" gutterBottom>
          Server Error
        </Typography>
      )}
      <Button onClick={() => navigate("/catalog")}>Go back to the store</Button>
    </Container>
  );
}
