import * as React from 'react';

export interface ITextAreaProps {
    name: string;
    value: string;
    onChange: (event: any) => void;
    className?: string;
    fixedSize?: boolean;
    disabled?: boolean;
    label?: string;
    maxlength?: number;
    placeholder?: string;
    readonly?: boolean;
    max?: number;
    focus?: boolean;
    error?: string;
    cols?: number;
    rows?: number;
}


const TextArea: React.StatelessComponent<ITextAreaProps> = (prop: ITextAreaProps) => {
    let wrapperClass = 'form-group';
    if (prop.error && prop.error.length > 0) {
        wrapperClass += " " + 'has-error';
    }

    let resize = {
        resize: 'none'
    }

    return (
        <div className={wrapperClass}>
            {prop.label && <label htmlFor={name}>{prop.label}</label>}
            <textarea
                name={prop.name}
                className={prop.className ? prop.className : ' '}
                placeholder={prop.placeholder}
                maxLength={prop.max}
                autoFocus={prop.focus}
                readOnly={prop.readonly}
                disabled={prop.disabled}
                cols={prop.cols}
                rows={prop.rows}
                onChange={prop.onChange}
                value={prop.value}
            >
            </textarea>
        </div>
    );
};

export default TextArea;
