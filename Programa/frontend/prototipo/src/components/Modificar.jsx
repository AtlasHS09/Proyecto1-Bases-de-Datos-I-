// Clase del Body para la funcionalidad de Modificar

import React from 'react';
import './App.css';
//bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
class Modificar extends React.Component {
 
 
  render() {
  
     
    return (
    
      <div className="maincontainer">

        <div class="container">
          <div class="py-5 text-center">
            
            <h2>Prototipo de Modificar</h2>
            <p class="lead">Aqui puede rellenar los datos del prototipo.</p>
          </div>
          <div class="row">
            <div class="col-md-8 order-md-1">
              <h4 class="mb-3">Datos del Ejemplo</h4>
              <form class="needs-validation" novalidate>
                <div class="row">
                  <div class="col-md-6 mb-3">
                    <label for="datoBorrar">Datos a Modificar</label>
                    <input type="text" class="form-control" id="datoBorrar" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por favor ingrese Datos Validos.
                    </div>
                  </div>
                  <div class="col-md-6 mb-3">
                    <label for="atributoBorrar">Atributo a Modiicar</label>
                    <input type="text" class="form-control" id="atributoBorrar" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por favor ingrese Datos Validos.
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-5 mb-3">
                    <label for="tabla">Tabla</label>
                    <select class="custom-select d-block w-100" id="tabla" required>
                      <option value="">Elija...</option>
                      <option>Estudiante</option>
                      <option>Profesor</option>
                      <option>Padre</option>
                      <option>Periodo Lectivo</option>
                      <option>Horario de Clases</option>
                      <option>Matricula</option>
                      <option>Factura</option>
                      <option>Grupo</option>
                    </select>
                    <div class="invalid-feedback">
                      Por favor ingrese una tabla valida.
                    </div>
                  </div>
                </div>
                <hr class="mb-4" />
              </form>
            </div>
          </div>
        </div>
     
      </div>
      
)
};
}
export default Modificar;