// Funcion para controlar las direcciones del Header, Body y Footer, dependiendo de la funcionalidad requerida.
// Entra: La direccion del Body a tomar. Sale: Llamada al Body requerido.

import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Navigation, Footer, Agregar, Modificar, Borrar, Listar } from "./components";
function App() {
  return (
    <div className="App">
      <Router>
        <Navigation />
        <Switch>
          <Route path="/" exact component={() => <Agregar />} />
          <Route path="/modificar" exact component={() => <Modificar />} />
          <Route path="/borrar" exact component={() => <Borrar />} />
          <Route path="/listar" exact component={() => <Listar />} />

        </Switch>
        <Footer />
      </Router>
    </div>
  );
}

export default App;
