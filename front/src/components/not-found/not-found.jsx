import OfferNotFoundIcon from '../../drawables/icons/offer-not-found-icon';

import './not-found.scss';

const NotFound = ({children}) => {
    return (
        <div className='offer-not-found-container'>
            <OfferNotFoundIcon />
            {children}
        </div>
    )
}
export default NotFound;