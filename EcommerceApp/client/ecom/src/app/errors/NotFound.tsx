import { Button, Divider, Paper, Typography } from "@mui/material";
import { Container } from "@mui/system";
import { Link } from "react-router-dom";

export default function NotFound() {
  return (
  <Container component={Paper} sx={{ height: 20 }}>
        <Typography gutterBottom variant="h3">Site Not Found...</Typography>
        <Divider />
        <Button fullWidth component={Link} to="/catalog">go back to store</Button>
  </Container>
  );
}
