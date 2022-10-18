import "./form-button.scss";

const FormButton = ({title, isSubmitting, isValid}) => {
    return (
        <button
            className='button'
            data-submitting={isSubmitting}
            data-disabled={!isValid}
            disabled={!isValid || isSubmitting}
        >
            <span className='text'>{title}</span>
            <span className='spinner'></span>
        </button>
    )
}


export default FormButton;