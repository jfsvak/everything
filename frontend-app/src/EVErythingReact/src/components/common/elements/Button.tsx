import * as React from 'react';

export interface IButtonProps {
    label: string;
    onClick: (event: any) => void;
    className?: string;
    disabled?: boolean;
}

const Button: React.StatelessComponent<IButtonProps> = (prop: IButtonProps) => {
    return (
        <button
            type="button"
            disabled={prop.disabled}
            className={"btn btn-primary " + (prop.className ? prop.className : " ")}
            onClick={prop.onClick}>{prop.label}</button>
    );
};

export default Button;
