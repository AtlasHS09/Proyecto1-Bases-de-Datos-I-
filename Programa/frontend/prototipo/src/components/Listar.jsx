// Clase del Body para la funcionalidad de Listar

import React from 'react';
import './App.css';
//bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
class Listar extends React.Component {
 
 
  render() {
  
     
    return (
    
      <div className="maincontainer">
        <div class="container">
          <div class="py-5 text-center">
            
            <h2>Prototipo de Listar Estudiantes</h2>
            <p class="lead">Aqui puede probar el prototipo.</p>
          </div>
          <div class="row">
            <div class="col-md-8 order-md-1">
              <form class="needs-validation" novalidate>                 
                <button class="btn btn-primary btn-lg btn-block" type="button">Listar Estudiantes</button>
              </form>
            </div>
          </div>
        </div>
     
      </div>
      
)
};
}
export default Listar;