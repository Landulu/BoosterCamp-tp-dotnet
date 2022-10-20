import { useState } from 'react';
import { useForm } from 'react-hook-form';

import FormInput from '../../components/form-input/form-input';
import FormButton from '../../components/form-button/form-button';
import {FormFeedBackSucces, FormFeedBackError } from '../../components/form-feedback/form-feedback';

import './createOffer.scss';

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
        },
        reset: true,
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
        reset: false,
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
        },
        reset: false,
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
        },
        reset: false,
    },
    {
        label: "Disponibilité",
        placeholder: "",
        name: "availability",
        type: "date",
        registerParams: {},
        reset: true,
    },
    {
        label: "Expiration",
        placeholder: "",
        name: "expiration",
        type: "date",
        registerParams: {},
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

const CreateOfferVieuw = ({OffersService}) => {


    const { register, handleSubmit, formState: {errors, isValid}, reset } = useForm({mode: 'onChange'});

    const [feedbackSucces, setFeedBackSucces] = useState(defaultFeedbackValues.succes);
    const [feedbackError, setFeedBackError] = useState(defaultFeedbackValues.error);
    const [isSubmitting, setIsSubmitting] = useState(false);

    const resetInputs = () => {
        const inputsShouldBeReseted = {};
        inputs.forEach(input => {
            if ( input.reset ) {
                inputsShouldBeReseted[input.name] = "";
            }
        })
        reset(inputsShouldBeReseted);
    }

    const onSubmit = (data) => {
        setIsSubmitting(true);
        setFeedBackSucces(defaultFeedbackValues.succes);
        setFeedBackError(defaultFeedbackValues.error);
        OffersService.createOffer({
            ...data,
            availability: new Date(data.availability).toISOString(),
            expiration: new Date(data.expiration).toISOString()
        })
        .then(() => {
            setFeedBackSucces({
                displayed: true,
                title: "Offre crée",
                message: "Votre offre a bien été soumise à validation, vous allez recevoir bientôt un mail pour la valider, une fois celle ci validée par vous et notre équipe, elle sera visible sur notre platforme"
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


    return (

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
                isSubmitting={isSubmitting}
                isValid={isValid}
            />
            
        </form>
    )
}


export default CreateOfferVieuw;