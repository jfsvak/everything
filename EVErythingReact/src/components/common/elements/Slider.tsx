import * as React from 'react';
import Slider from 'react-rangeslider';
import 'react-rangeslider/lib/index.css';

export interface ISliderInputProps {
    value: number;
    onChange: (value: any) => void;
    min?: number;
    max?: number;
    step?: number;
    orientation?: string;
    reverse?: boolean;
    tooltip?: boolean;
    labels?: any;
    handleLabel?: string;
    format?: (value: any) => any;
    onChangeStart?: (value: any) => void;
    onChangeComplete?: (value: any) => void;
    showCustomTooltip?: boolean;
}

//This component is based on "react-rangeslider" dependancies which need to be install
const SliderInput: React.StatelessComponent<ISliderInputProps> = (prop: ISliderInputProps) => {
    return (
        <div className="slider-input">
            <div className={"slider-holder " + (prop.showCustomTooltip ? "shorter" : "")}>
                <Slider
                    value={prop.value}
                    onChange={prop.onChange}
                    min={prop.min}
                    max={prop.max}
                    step={prop.step}
                    orientation={prop.orientation}
                    reverse={prop.reverse}
                    tooltip={prop.tooltip}
                    labels={prop.labels}
                    handleLabel={prop.handleLabel}
                    format={prop.format}
                    onChangeStart={prop.onChangeStart}
                    onChangeComplete={prop.onChangeComplete} />
            </div>
            {prop.showCustomTooltip && <div className="custom-tooltip"><span>{prop.value}%</span></div>}
        </div>

    );
};

export default SliderInput;
