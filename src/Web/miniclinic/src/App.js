import React, { Component } from "react";
import "./App.css";
import { connect } from "react-redux";

import Login from "./components/Login";
import { Container, Row } from "react-bootstrap";

class App extends Component {
  render() {
    return (
      <Container fluid>
        {this.props.loggedIn === true ? <div>Logged</div> : <Login />}
      </Container>
    );
  }
}

const mapStateToProps = state => {
  return {
    loggedIn: state.account.loggedIn
  };
};

const mapDispatchToProps = {};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App);
