import * as React from 'react';
import { Image, OverlayTrigger, Tooltip  } from 'react-bootstrap';


interface State {}

interface Props {
    onClick?: () => void
    src: string
    width: string
    toolTip: string
    disabled?: boolean
    clickable?: boolean
}

const getInitialState = () => {
    const initialState = {};
    return initialState;
}

export class ImageWithTooltip extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);  
    }

    renderToolTip() {
        return (
            <Tooltip id="tooltip">
                <strong>{this.props.toolTip}</strong>
            </Tooltip>
        );
    }

    render() {

        let className: string = this.props.clickable ? 'clickable' : '';

        return (
            <OverlayTrigger
                placement="top"
                overlay={this.renderToolTip()}>
                <div width='100%' style={{ float: 'left' }}>
                    <Image
                        className={className}
                        disabled={this.props.disabled}
                        src={this.props.src}
                        onClick={this.props.onClick}
                        width={this.props.width}
                        thumbnail
                        responsive
                    />
                </div>
            </OverlayTrigger>
            );
    }
}

