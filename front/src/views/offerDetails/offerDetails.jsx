import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import Loader from '../../components/loader/loader';
import './offerDetails.scss';

const OfferDtails = ({OffersService}) => {


    const [offer, setOffer] = useState({});
    const [isLoading, setIsLaoding] = useState(true);
    const { id } = useParams();

    useEffect(() => {

        
        OffersService.getOfferById(id)
        .then(offer => setOffer(offer))
        .catch((error) => console.log(error))
        .finally(() => setIsLaoding(false));


    })


    return (

        <>
            {
                isLoading
                ?   <Loader />
                :   <div className="offer-details">
                        <div className="offfer-header">
                            <div className="image-container">
                                <img src="https://picsum.photos/500/320" alt="" />
                            </div>
                            <div className="text-container">
                                <h1 className='title'>{offer.title}</h1>
                                <div className="middle">
                                    <p className='description'>{offer.description}</p>
                                    <p className='companyName'>{offer.companyName}</p>
                                </div>
                            </div>
                        </div>
                    </div>
            }
        </>
    )
}


export default OfferDtails;