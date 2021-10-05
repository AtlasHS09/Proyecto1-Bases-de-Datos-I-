// Clase del Body para la funcionalidad de Agregar

import React from 'react';
import './App.css';
//bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
class Agregar extends React.Component {
 
 
  render() {
  
     
    return (
    
      <div className="maincontainer">
        <div class="container">
          <div class="py-5 text-center">
            
            <h2>Prototipo de Agregar Estudiantes</h2>
            <p class="lead">Aqui puede rellenar los datos del prototipo.</p>
          </div>
          <div class="row">
            <div class="col-md-8 order-md-1">
              <h4 class="mb-3">Datos del Ejemplo</h4>
              <form class="needs-validation" novalidate>
                <div class="row">
                  <div class="col-md-6 mb-3">
                    <label for="firstName">Codigo de Usuario</label>
                    <input type="int" class="form-control" id="firstName" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por Favor ingrese un codigo valido.
                    </div>
                  </div>
                  <div class="col-md-6 mb-3">
                    <label for="lastName">Grados Cursados</label>
                    <input type="int" class="form-control" id="lastName" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por Favor ingrese un numero valido.
                    </div>
                  </div>
                  <div class="col-md-6 mb-3">
                    <label for="lastName">Periodo Lectivo</label>
                    <input type="int" class="form-control" id="lastName" placeholder="" value="" required />
                    <div class="invalid-feedback">
                    Por Favor ingrese un periodo valido.
                    </div>
                  </div>
                </div>
                
                <hr class="mb-4" />
                <button class="btn btn-primary btn-lg btn-block" type="button">Agregar Estudiante</button>
              </form>
            </div>
          </div>
        </div>
     
      </div>
      
)
};
}
export default Agregar;