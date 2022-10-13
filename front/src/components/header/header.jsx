import { useState } from 'react';
import './header.scss';

const defaultNavbar = [
    {
        id: 2,
        title: "Créer une offre",
        link: "#",
        isActif: false,
        order: 2,
    },
    {
        id: 1,
        title: "Offres",
        link: "#",
        isActif: true,
        order: 1,
    }
]

const Link = ({isActif, link, title, handleClick}) => (
    <a data-actif={isActif ? true : false} className='link' href={link} onClick={handleClick} >{title}</a>
)

const Header = () => {

    const [nav, setNav] = useState(defaultNavbar);

    const handleClick = (event, id) => {
        event.preventDefault();
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
                        nav.sort((a,b) => a.order - b.order)
                        .map(link => <Link key={link.id} {...link} handleClick={(e) => handleClick(e, link.id)} />)
                    }
                </nav>
            </div>
        </header>
    )
}


export default Header;