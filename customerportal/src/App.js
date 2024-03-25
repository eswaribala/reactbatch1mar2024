import logo from './logo.svg';
import './App.css';
import React, {Component, createContext, useEffect, useState} from "react";
import Logo from './components/Logo/Logo'
import Banner from './components/Banner/Banner'
import LoginForm from './components/LoginForm/LoginForm'
import Registration from "./components/registration/registration";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Dashboard from "./components/dashboard/dashboard";
import {useSelector} from "react-redux";
import Customers from "./components/customers/customers";
function App() {
//react hook -- state initialization
  const[currentTime,setCurrentTime]=useState(new Date())
  const[isRegister,setIsRegister] = useState(false)
  const [isSubmit,setIsSubmit]=useState(false);
 // const registrationState= useSelector((state)=>state.registrationReducer)


    //react hook - react effect
    useEffect(()=>{
        setInterval(()=>{
            setCurrentTime(new Date())
        },1000)
    },[currentTime]);

  function handleRegisterChange(value){
      setIsRegister(value)
  }

  function handleSubmitChange(value){
      setIsSubmit(value);
  }

  return (
      <div className="App">


          {(!isSubmit) && (
           <div>
          <header className="App-header">
              <Logo/>
              <h1 className="multicolortext">Customer Portal</h1>
              <h4>{currentTime.toLocaleTimeString()}</h4>
          </header>
               {/*{
                   (registrationState.isLoaded)?
                       <>
                           <p>{registrationState.user.name.firstName}</p>
                       </> :

                       <>
                           <h6>No User Registered</h6>
                       </>
               }*/}
          <section className="Form-header">

              <div className="Form-header">
              <Banner/>
              {(!isRegister)?<LoginForm registerStatus={handleRegisterChange} submitStatus={handleSubmitChange} />:<Registration/>}
              </div>
          </section>
          </div>
          )
          }
          {(isSubmit) &&(
         <section>
          <Routes>
              <Route path="/dashboard" element={<Dashboard/>}></Route>

              <Route path="/customers" element={<Customers/>}></Route>

              <Route path="/" element={<App/>}></Route>
          </Routes>
         </section>
              )}
      </div>
  );
}

export default App;

/*
export class App extends Component{
    constructor(props, context) {
        super(props, context);
        this.state={
            currentTime:new Date()
        }
    }

    timerEvent=()=>{
        this.setState({
            currentTime:new Date()
        })
    }


    componentDidMount() {
        //super.componentDidMount();
        setInterval(this.timerEvent,1000);

    }

    render() {
       return(
           <div className="App">
               <header className="App-header">
               <Logo/>
               <h1 className="multicolortext">Customer Portal</h1>
               <h4>{this.state.currentTime.toLocaleTimeString()}</h4>
               </header>
           </div>
       );
    }
}
*/