import { Link } from 'react-router-dom';
import './offer.scss';

const Offer = ({offer}) => {

    const sliceText = (text) => {
        if ( text.length > 250 ) return `${text.slice(0,250)}...`;
        else return text;
    }


    return (
        <div className="offer-item">
            <h2 className='title'>{offer.title}</h2>
            <div className="middle">
                <p className='description'>{sliceText(offer.description)}</p>
                <p className='company'>{offer.companyName}</p>
            </div>
            <div className="actions">
                <Link className='link' to={`/offers/contact/${offer.id}` }>Contacter</Link>
                <Link className='link' to={`/offers/${offer.id}` }>Détails de l'offre</Link>
            </div>
        </div>
    )
}

export default Offer;