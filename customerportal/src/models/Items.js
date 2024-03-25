import React from 'react';

import {useNavigate} from "react-router-dom";

export  const items=[{
    label: 'Home',
    icon: 'pi pi-home'
},
    {
        label: 'MyTickets',
        icon: 'pi pi-ticket'
    },
    {
        label: 'Due Payment',
        icon: 'pi-money-bill',
        url: "/customers"
       /* command: () => {
          //  event.preventDefault()
            window.location.href="/customers"
        }*/
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
