import styled from "styled-components";
import { baseColors } from "../../style/colors/colors";
import { BaseSearchBar } from "../../style/BaseSearchBar/base-search-bar";
import { FaBell, FaUser } from "react-icons/fa";
import { HomeList } from "./components/home-list/home-list";
import { HomeBanner } from "./components/home-banner/home-banner";

const HomePageStyle = styled.main`
  background: ${baseColors.black};
  color: ${baseColors.pink};
  padding: 48px;
  > header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 3%;
    width: 100%;
    margin-bottom: 48px;
    nav {
      display: flex;
      align-items: center;
      gap: 48px;
      color: ${baseColors.white};
      text-transform: uppercase;
      div {
        transition: all 300ms;
        cursor: pointer;
        :hover {
          color: ${baseColors.pink};
        }
      }
    }
  }
  > article {
    margin-bottom: 48px;
    display: flex;
    flex-direction: column;
    gap: 48px;
  }
  > footer {
    width: 100%;
    background: ${baseColors.black1};
    border-radius: 12px;
    padding: 24px;
    color: ${baseColors.gray1};
    display: flex;
    flex-direction: column;
    gap: 8px;
  }
`;

export const HomePage = () => {
  const headerOptions = [
    {
      text: "Tags",
      action: () => console.log("hihihi"),
    },
    {
      text: "Request",
      action: () => console.log("hihihi"),
    },
    {
      text: "Random",
      action: () => console.log("hihihi"),
    },
    {
      text: "Calendar",
      action: () => console.log("hihihi"),
    },
  ];
  const footerMock = [
    "nao quero saber mano vaza",
    "e vai toma no cu",
    "o unico que tava de hack aqui era vc",
    "entao fodase",
    "se vc fosse da minhna cidade eu ia te dar um pau tao grande",
    "toma no cu",
    "na moral",
    "no to de brincadeira",
    "nao",
  ];
  return (
    <HomePageStyle>
      <header>
        <img src="https://cdn.discordapp.com/emojis/983131312166695003.webp?size=96&quality=lossless" alt="Logo" />
        <BaseSearchBar></BaseSearchBar>
        <nav>
          {headerOptions.map((option, i) => (
            <div key={i} onClick={option.action}>
              <h2>{option.text}</h2>
            </div>
          ))}
          <FaUser></FaUser>
          <FaBell></FaBell>
        </nav>
      </header>
      <article>
        <HomeBanner
          imgSrc="https://cdn.discordapp.com/attachments/1016931276772614185/1028351169791270912/IMG_2633.gif"
          onClick={() => null}
        />
        <HomeList items={[1, 2, 3, 4, 5]} title="new releases" onClickAll={() => null} onClickItem={() => null} />
        <HomeList items={[1, 2, 3]} title="trending" onClickAll={() => null} onClickItem={() => null} />
      </article>
      <footer>
        {footerMock.map((e, i) => (
          <h4 key={i}>{e}</h4>
        ))}
      </footer>
    </HomePageStyle>
  );
};
