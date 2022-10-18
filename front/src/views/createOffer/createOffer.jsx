import { useRef, useState } from 'react';
import { useForm } from 'react-hook-form';

import FormInput from '../../components/form-input/form-input';
import FormButton from '../../components/form-button/form-button';
import {FormFeedBackSucces, FormFeedBackError } from '../../components/form-feedback/form-feedback';

import './createOffer.scss';
import { useEffect } from 'react';

const inputs = [
    {
        label: "Titre",
        placeholder: "e.g. PC Portable de la marque Dell",
        name: "title",
        type: "text",
        registerParams: {
            required: "Le champ titre est obligatoire",
            minLength: {
                value: 10,
                message: "Le titre dois au moins avoir 10 caractères"
            },
            maxLength: {
                value: 120,
                message: "Le titre dois au maximum avoir 120 caractères"
            }
        }
    },
    {
        label: "Description",
        placeholder: "e.g. Ma superbe description de mon super pc Dell de l'espace, ma superbe description oup oup oup ...",
        name: "description",
        type: "textarea",
        registerParams: {
            required: "Le champ description est obligatoire",
            minLength: {
                value: 20,
                message: "La description dois au moins avoir 20 caractères"
            },
            maxLength: {
                value: 560,
                message: "La description dois au maximum avoir 560 caractères"
            }
        }
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
        }
    },
    {
        label: "Entreprise",
        placeholder: "e.g. Soat",
        name: "companyName",
        type: "text",
        registerParams: {
            required: "Le champ entreprise est obligatoire",
            minLength: {
                value: 3,
                message: "Le champ entreprise dois au moins avoir 3 caractères"
            },
            maxLength: {
                value: 120,
                message: "Le champ entreprise dois au maximum avoir 120 caractères"
            }
        }
    },
    {
        label: "Adresse",
        placeholder: "e.g. 89 Quai Panhard et Levassor, 75013",
        name: "address",
        type: "text",
        registerParams: {
            required: "Le champ adresse est obligatoire",
            minLength: {
                value: 10,
                message: "Le champ adresse dois au moins avoir 10 caractères"
            },
            maxLength: {
                value: 220,
                message: "Le champ adresse dois au maximum avoir 220 caractères"
            }
        }
    },
    {
        label: "Disponibilité",
        placeholder: "",
        name: "availability",
        type: "date",
        registerParams: {
            // valueAsDate: "Le champ disponibilité de l'offre est incorrecte",
            // valueAsDate: true,
        }
    },
    {
        label: "Expiration",
        placeholder: "",
        name: "expiration",
        type: "date",
        registerParams: {
            // valueAsDate: "Le champ expiration de l'offre est incorrecte",
            // valueAsDate: true,
        }
    }
];

const CreateOfferVieuw = ({OffersService}) => {


    const { register, handleSubmit, formState: {errors, isValid, isSubmitting} } = useForm({mode: 'onChange'});

    const [feedbackSucces, setFeedBackSucces] = useState({
        displayed: false,
        title: "",
        message: "",
    })
    const [feedbackError, setFeedBackError] = useState({
        display: false,
        errors: []
    })

    const onSubmit = (data) => {
        OffersService.createOffer({
            // ...data,
            // availability: new Date(data.availability).toISOString(),
            // expiration: new Date(data.expiration).toISOString()
            "title": "titre de mon offer",
            "description": "string",
            "email": "stringgmail.com",
            "companyName": "string",
            "address": "string",
            "availability": "2023-10-18T14:42:39.562Z",
            "expiration": "2023-09-18T14:42:39.562Z"
        })
        .then((response) => console.log(response))
        .catch((error) => {
            console.log(error.data.errors)
        })
        // setFeedBack({...feedback, display: true});
    }

    // useEffect(() => {
    //     if ( feedback.display ) {
    //         const feedbackTimeout = setInterval(() => {
    //             setFeedBack({...feedback, display: false})
    //         }, 5000)
    //         return () => clearTimeout(feedbackTimeout);
    //     }
    // }, [feedback])


    return (
        <>
        <button onClick={onSubmit}>Submit</button>
        <form className='create-offer-form' onSubmit={handleSubmit(onSubmit)}>



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
                // isSubmitting={isSubmitting}
                // isValid={isValid}
                isSubmitting={false}
                isValid={true}
            />
            
        </form>
        </>
    )
}


export default CreateOfferVieuw;