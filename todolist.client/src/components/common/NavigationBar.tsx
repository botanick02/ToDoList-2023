import { Container, Nav, Navbar } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import { useAppDispatch, useAppSelector } from "../../redux/hooks";
import { ChangeEvent } from "react";
import { setCurrentStorageSource } from "../../redux/reducers/storageSource-slice";

const NavigationBar = () => {
  const storageSources = useAppSelector(
    (state) => state.storageSources.storagesList
  );
  const dispatch = useAppDispatch();

  const handleSelectChange = (event: ChangeEvent<HTMLSelectElement>) => {
    dispatch(setCurrentStorageSource(event.target.value));
  };

  return (
    <Navbar bg="light" expand="lg" className="shadow">
      <Container>
        <Navbar.Brand href="/">ToDoList</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="Categories">Categories</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Form.Select
          aria-label="Storage source"
          className="w-25"
          onChange={handleSelectChange}
        >
          {storageSources.length > 0 &&
            storageSources.map((source) => (
              <option key={source} value={source}>
                {source}
              </option>
            ))}
        </Form.Select>
      </Container>
    </Navbar>
  );
};

export default NavigationBar;
