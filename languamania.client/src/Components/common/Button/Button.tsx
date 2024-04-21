import "./styles/index.scss";

export default function Button(props: any) {
    return (
        <button
            className={props.className}
            onClick={props.onClick}
            type={props.type}
        >
            {props.text}
        </button>
    );
}
