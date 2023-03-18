import styled from "styled-components";
import { BaseCardVideo } from "../../../../style/BaseCardVideo/base-card-video";
import { BaseButton } from "../../../../style/BaseButton/base-button";

type HomeListProps = {
  title: string;
  items: any[];
  onClickItem: (item: any) => void;
  onClickAll: () => void;
};

const HomeListStyle = styled.section`
  display: flex;
  flex-direction: column;
  width: 100%;
  .highlight-text {
    display: flex;
    justify-content: space-between;
  }
  .cards {
    display: flex;
    gap: 24px;
  }
`;

export const HomeList = ({ title, items, onClickItem, onClickAll }: HomeListProps) => {
  return (
    <HomeListStyle>
      <div className="highlight-text">
        {title} <BaseButton text="All" onClick={onClickAll} />
      </div>
      <div className="cards">
        {items.map((card, i) => (
          <BaseCardVideo key={i} title="aaaaaaaaaaaa" onClick={() => onClickItem(card)}></BaseCardVideo>
        ))}
      </div>
    </HomeListStyle>
  );
};
