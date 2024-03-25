import React, {createContext} from 'react';
import PropTypes from 'prop-types';
import './dashboardmenu.css';
import Logo from "../Logo/Logo";
import {Menubar} from "primereact/menubar";
import {useNavigate} from "react-router-dom";
const Dashboardmenu = ({name}) => {
    const navigate=useNavigate()

    const UserContext = createContext();

    const items=[{
        label: 'Home',
        icon: 'pi pi-home',
        command: () => {
            //  event.preventDefault()
            // window.location.href = "/customers"
            navigate("/dashboard")
        }
    },
        {
            label: 'MyTickets',
            icon: 'pi pi-ticket'
        },
        {
            label: 'Due Payment',
            icon: 'pi-money-bill',

            command: () => {
                //  event.preventDefault()
                // window.location.href = "/customers"
                navigate("/customers")
            }
        },
        {
            label: 'Receipts',
            icon: 'pi pi-book'
        },
        {
            label: 'More',
            icon: 'pi pi-search',
            items:[{
                label: 'Branch Locator',
                icon: 'pi pi-globe'
            },
                {
                    label: 'New/Vacancy',
                    icon: 'pi pi-plus'
                },
                {
                    label: 'FAQ',
                    icon: 'pi pi-question-circle'
                }
            ]

        }


    ]
    return(
    <div className="dashboardmenu">
        <header className="header">
            <Logo/>
            <Menubar key={items.label} model={items}></Menubar>
            <div className="welcome">
                <h4>Hi&nbsp;&nbsp;{name}</h4>
                &nbsp;&nbsp;<span className="pi pi-user"></span>
            </div>
        </header>
    </div>
)};

Dashboardmenu.propTypes = {};

Dashboardmenu.defaultProps = {};

export default Dashboardmenu;
