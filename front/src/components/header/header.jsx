import { useEffect, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';

import './header.scss';

const defaultNavbar = [
    {
        id: 1,
        title: "Offres",
        link: "/offers",
        isActif: false,
        order: 1,
    }
];

const CustomLink = ({isActif, link, title, handleClick, id}) => (
    <Link className='link' data-actif={isActif ? true : false} to={link} onClick={() => handleClick(id)}>{title}</Link>
)

const Header = () => {

    const [nav, setNav] = useState([]);
    const location = useLocation();


    useEffect(() => {

        const newNav = defaultNavbar.map(item => {
            if ( item.link !== location.pathname ) return item;
            else return {...item, isActif: true};
        }).sort((a,b) => a.order - b.order)

        setNav(newNav);

    }, [location]);

    const handleClick = (id) => {
        const newNav = nav.map( link => {
            if ( link.id === id && !link.isActif ) return {...link, isActif: true};
            else return {...link, isActif: false};
        })
        setNav(newNav);
    }

    return (
        <header className='header'>
            <div className="sub-header">
                <div className="logo">Anti Gaspi</div>
                <nav className='nav-bar'>
                    {
                        nav.map(link => <CustomLink key={link.id} {...link} id={link.id} handleClick={handleClick} />)
                    }
                </nav>
            </div>
        </header>
    )
}


export default Header;