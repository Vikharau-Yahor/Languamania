import Header from "./Header.tsx";
import Content from "./Content.tsx";
import Footer from "./Footer.tsx";
import "./styles/index.scss";

export default function Layout() {
    return (
        <>
            <Header />
            <Content />
            <Footer />
        </>
    );
}
