// Funcion general de navegacion del sistema, asi como el header universal. 
// Entra: La direccinon del Body actual. Sale: La direccion del Body a tomar.

import React from "react";
import { Link, withRouter } from "react-router-dom";

function Navigation(props) {
  return (
    <div className="navigation">
      <nav class="navbar navbar-expand navbar-dark bg-dark">
        <div class="container">
          <Link class="navbar-brand" to="/">
          Sistema de Gestion de Matriculas: Prototipo de Estudiante
          </Link>

          <div>
            <ul class="navbar-nav ml-auto">
              <li
                class={`nav-item  ${
                  props.location.pathname === "/" ? "active" : ""
                }`}
              >
                <Link class="nav-link" to="/">
                  Agregar
                  <span class="sr-only">(current)</span>
                </Link>
              </li>
              <li
                class={`nav-item  ${
                  props.location.pathname === "/modificar" ? "active" : ""
                }`}
              >
                <Link class="nav-link" to="/modificar">
                  Modificar
                </Link>
              </li>
              <li
                class={`nav-item  ${
                  props.location.pathname === "/listar" ? "active" : ""
                }`}
              >
                <Link class="nav-link" to="/listar">
                  Listar
                </Link>
              </li>
              <li
                class={`nav-item  ${
                  props.location.pathname === "/borrar" ? "active" : ""
                }`}
              >
                <Link class="nav-link" to="/borrar">
                  Borrar
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  );
}

export default withRouter(Navigation);