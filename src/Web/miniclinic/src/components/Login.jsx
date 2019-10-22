import React, { Component } from "react";

import { Form, Card, Button, Spinner } from "react-bootstrap";

import { login } from "../store/actions/accountActions";

import { connect } from "react-redux";

import * as Yup from "yup";
import { Formik } from "formik";

const loginValidationScheme = Yup.object().shape({
  username: Yup.string().required("Please enter username"),
  password: Yup.string().required("Please enter password")
});

class Login extends Component {
  render() {
    return (
      <React.Fragment>
        <Card
          className="text-light shadow-lg"
          style={{
            height: "300px",
            backgroundColor: "#1e90ff",
            borderWidth: "0px",
            position: "absolute",
            left: "50%",
            top: "30%",
            width: "350px",
            transform: "translate(-50%, -50%)"
          }}
        >
          <Card.Body>
            <Card.Title className="text-center mt-2">
              Login to Mini Clinic
            </Card.Title>
            <Formik
              initialValues={{
                username: "",
                password: ""
              }}
              validationSchema={loginValidationScheme}
              onSubmit={(values, actions) => {
                setTimeout(() => {
                  this.props.login({
                    username: values.username,
                    password: values.password
                  });
                  actions.setSubmitting(false);
                }, 3000);
              }}
            >
              {({
                values,
                errors,
                touched,
                handleChange,
                handleBlur,
                handleSubmit,
                isSubmitting
              }) => {
                return (
                  <Form
                    className="p-3 rounded"
                    noValidate
                    onSubmit={handleSubmit}
                  >
                    <Form.Group>
                      <Form.Control
                        id="username"
                        name="username"
                        className="text-center"
                        placeholder="User name"
                        value={values.username}
                        isValid={touched.username && !errors.username}
                        isInvalid={touched.username && !!errors.username}
                        onBlur={handleBlur}
                        onChange={handleChange}
                      />
                      <Form.Control.Feedback type="invalid">
                        {errors.username}
                      </Form.Control.Feedback>
                    </Form.Group>
                    <Form.Group>
                      <Form.Control
                        id="password"
                        name="password"
                        className="text-center"
                        type="password"
                        placeholder="Password"
                        value={values.password}
                        isValid={touched.password && !errors.password}
                        isInvalid={touched.password && !!errors.password}
                        onBlur={handleBlur}
                        onChange={handleChange}
                      />
                      <Form.Control.Feedback type="invalid">
                        {errors.password}
                      </Form.Control.Feedback>
                    </Form.Group>
                    <div className="float-right">
                      <Button className="m-2" size="sm" variant="dark">
                        Create Account
                      </Button>
                      <Button
                        disabled={isSubmitting}
                        size="sm"
                        variant="success"
                        type="submit"
                      >
                        {!isSubmitting ? (
                          "Login"
                        ) : (
                          <React.Fragment>
                            <Spinner size="sm" animation="border" />
                            <span className="ml-2">Logging in</span>
                          </React.Fragment>
                        )}
                      </Button>
                      <p>{this.props.message}</p>
                    </div>
                  </Form>
                );
              }}
            </Formik>
          </Card.Body>
        </Card>
      </React.Fragment>
    );
  }
}

const mapStateToProps = state => {
  return {
    loggedIn: state.account.loggedIn,
    message: state.account.message
  };
};

const mapDispatchToProps = {
  login: login
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Login);
