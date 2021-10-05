// Clase del Body para la funcionalidad de Borrar

import React from 'react';
import './App.css';
//bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
class Borrar extends React.Component {
 
 
  render() {
  
     
    return (
    
      <div className="maincontainer">
        <div class="container">
          <div class="py-5 text-center">
            
            <h2>Prototipo de Borrar Estudiantes</h2>
            <p class="lead">Aqui puede rellenar los datos del prototipo.</p>
          </div>
          <div class="row">
            <div class="col-md-8 order-md-1">
              <h4 class="mb-3">Datos del Ejemplo</h4>
              <form class="needs-validation" novalidate>
                <div class="row">
                  <div class="col-md-6 mb-3">
                    <label for="datoBorrar">Codigo del Estudiante a Borrar</label>
                    <input type="int" class="form-control" id="datoBorrar" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por favor ingrese Datos Validos.
                    </div>
                  </div>
                </div>
                <hr class="mb-4" />
                <button class="btn btn-primary btn-lg btn-block" type="button">Borrar Estudiante</button>
                <hr class="mb-4" />
              </form>
            </div>
          </div>
        </div>
     
      </div>
      
)
};
}
export default Borrar;