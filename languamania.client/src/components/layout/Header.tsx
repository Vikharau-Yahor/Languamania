export default function Header() {
    const divStyles: React.CSSProperties = { display: 'flex', height: '75px', alignContent: 'center', justifyContent: 'center', backgroundColor: 'rgb(227 227 227)' };

    return (
        <>
            <div style={divStyles}>
                <p>Menu</p>
            </div>
        </>
    );
}