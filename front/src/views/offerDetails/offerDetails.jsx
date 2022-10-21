import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import Loader from '../../components/loader/loader';
import NotFound from '../../components/not-found/not-found';
import './offerDetails.scss';

const OfferDtails = ({OffersService}) => {


    const [offer, setOffer] = useState({});
    const [isLoading, setIsLaoding] = useState(true);
    const { id } = useParams();

    useEffect(() => {

        
        OffersService.getOfferById(id)
        .then(offer => setOffer(offer))
        .finally(() => setIsLaoding(false));


    }, [OffersService, id]);


    return (

        <>
            {
                isLoading
                ?   <Loader />
                :   !offer.id
                    ?   <NotFound>
                            <p>Désolé, L'offre n'existe plus</p>
                            <p>La bonne nouvelle, nous avons plein d'autres, vous les trouverais <Link className='not-found-link' to="/offers">ICI</Link></p>
                        </NotFound>
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
                                    <Link className='link' to={`/offers/contact/${offer.id}`}>Contacter</Link>
                                </div>
                            </div>
                        </div>
            }
        </>
    )
}


export default OfferDtails;