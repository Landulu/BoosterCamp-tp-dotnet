import { useEffect, useState } from 'react';
import Offer from '../../components/offer/offer';
import Loader from '../../components/loader/loader';
import './offersList.scss';

const Offers = ({OffersService}) => {


    const [offersList, setOffersList] = useState([]);
    const [isLoading, setIsLoading] = useState(true);


    useEffect(() => {
        OffersService.getOffers()
        .then(offers => offers && setOffersList(offers))
        .catch(error => console.log(error))
        .finally(() => setIsLoading(false));
    })



    return (
        <div className="offer-container">

            {
                isLoading
                ?   <Loader />
                :   <div className="offer-list">
                        {
                            offersList.map(offer => <Offer key={offer.id} offer={offer} /> )
                        }
                        
                    </div>
            }
        </div>
    )
}


export default Offers;