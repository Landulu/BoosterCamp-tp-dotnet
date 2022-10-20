import { useState, useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { Link, useParams } from 'react-router-dom';

import Loader from '../../components/loader/loader';
import NotFound from '../../components/not-found/not-found';

import FormInput from '../../components/form-input/form-input';
import FormButton from '../../components/form-button/form-button';
import {FormFeedBackSucces, FormFeedBackError } from '../../components/form-feedback/form-feedback';

import OfferNotFoundIcon from '../../drawables/icons/offer-not-found-icon';

import './offerContact.scss';

const inputs = [
    {
        label: "Prénom",
        placeholder: "e.g. Rabah",
        name: "firstName",
        type: "text",
        registerParams: {
            required: "Le prénom est obligatoire",
            minLength: {
                value: 2,
                message: "Le champ prénom dois au moins avoir 2 caractères"
            },
            maxLength: {
                value: 60,
                message: "Le champ prénom dois au maximum avoir 60 caractères"
            }
        },
        reset: true,
    },
    {
        label: "Nom",
        placeholder: "e.g. Ghiles",
        name: "lastname",
        type: "text",
        registerParams: {
            required: "Le nom est obligatoire",
            minLength: {
                value: 2,
                message: "La champ nom dois au moins avoir 2 caractères"
            },
            maxLength: {
                value: 60,
                message: "La champ nom dois au maximum avoir 60 caractères"
            }
        },
        reset: true,
    },
    {
        label: "Téléphone",
        placeholder: "e.g. +",
        name: "phone",
        type: "number",
        registerParams: {
            required: "Le champ téléphone est obligatoire",
            minLength: {
                value: 10,
                message: "Le champ numéro de téléphone dois au moins avoir 10 chiffres"
            },
            maxLength: {
                value: 12,
                message: "Le champ numéro de téléphone dois au plus avoir 12 chiffres"
            }
        },
        reset: true,
    },
    {
        label: "Email",
        placeholder: "e.g. contact@soat.fr",
        name: "email",
        type: "text",
        registerParams: {
            required: "Le champ email est obligatoire",
            pattern: {
                value: /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/,
                message: "Le champ email est incorrect",
            }
        },
        reset: true,
    },
    {
        label: "Message",
        placeholder: "e.g. On écrit sur les murs le nom de ceux qu'on aime, Des messages pour les jours à venir, On écrit sur les murs à l'encre de nos veines, On dessine tout ce que l'on voudrait dire...",
        name: "message",
        type: "textarea",
        registerParams: {
            required: "Le champ message est obligatoire",
            minLength: {
                value: 10,
                message: "Le champ message dois au moins avoir 10 caractères"
            },
            maxLength: {
                value: 550,
                message: "Le champ entreprise dois au maximum avoir 550 caractères"
            }
        },
        reset: true,
    }
];


const defaultFeedbackValues = {
    succes: {
        displayed: false,
        title: "",
        message: "",
    },
    error: {
        display: false,
        errors: [],
    }
}

const OfferContact = ({OffersService}) => {

    const { register, handleSubmit, formState: {errors, isValid}, reset } = useForm({mode: 'onChange'});

    const [feedbackSucces, setFeedBackSucces] = useState(defaultFeedbackValues.succes);
    const [feedbackError, setFeedBackError] = useState(defaultFeedbackValues.error);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [offerNotFound, setOfferNotFound] = useState(false);
    const [isLoading, setIsLoading] = useState(true);

    const { id } = useParams();

    const resetInputs = () => {
        const inputsShouldBeReseted = {};
        inputs.forEach(input => {
            if ( input.reset ) {
                inputsShouldBeReseted[input.name] = "";
            }
        })
        reset(inputsShouldBeReseted);
    }

    const onSubmit = (data, id) => {
        setIsSubmitting(true);
        setFeedBackSucces(defaultFeedbackValues.succes);
        setFeedBackError(defaultFeedbackValues.error);

        OffersService.contactOffer({
            ...data,
            phone: data.phone.to
        }, id)
        .then(() => {
            setFeedBackSucces({
                displayed: true,
                title: "Message envoyé",
                message: "Votre message a bien été envoyé à l'annonceur de l'offre"
            })
            resetInputs();
        })
        .catch(({data: {errors}}) => {
            const backendErrors = [];
            for ( const [key, value] of Object.entries(errors) ) {
                backendErrors.push(value[0])
            }
            setFeedBackError({
                display: true,
                errors: backendErrors,
            })
        })
        .finally(() => setIsSubmitting(false));
    }


    useEffect(() => {
        OffersService.getOfferById(id)
        .catch(() => setOfferNotFound(true))
        .finally(() => setIsLoading(false))
    }, [OffersService, isLoading])


    return (
        <>
        {
            isLoading
            ?   <Loader />
            :   offerNotFound
                ?   <NotFound>
                        <p>Désolé, L'offre n'existe plus</p>
                        <p>La bonne nouvelle, nous avons plein d'autres, vous les trouverais <Link className='not-found-link' to="/offers">ICI</Link></p>
                    </NotFound>
                :   <form className='create-offer-form' onSubmit={handleSubmit((data) => onSubmit(data, id))}>

                        {
                            inputs.map(input => <FormInput
                                key={input.name}
                                label={input.label}
                                placeholder={input.placeholder}
                                name={input.name}
                                type={input.type}
                                error={errors[input.name]}
                                errorText={errors[input.name]?.message}
                                register={register}
                                registerParams={input.registerParams}
                            />)
                        }

                        {
                            feedbackSucces.displayed && <FormFeedBackSucces
                                title={feedbackSucces.title}
                                message={feedbackSucces.message}
                            />
                        }

                        {
                            feedbackError.display && <FormFeedBackError errors={feedbackError.errors} />
                        }

                        <FormButton
                            title="Créer"
                            isSubmitting={isSubmitting}
                            isValid={isValid}
                        />
                    
                    </form>
        }
        </>
    )
}

export default OfferContact;