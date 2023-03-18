import styled from "styled-components";
import { baseColors } from "../../../../style/colors/colors";

type HomeBannerProps = {
  imgSrc: string;
  onClick: () => void;
};

const HomeBannerStyle = styled.div`
  height: 170px;
  width: 100%;
  border-radius: 10px;
  background: ${baseColors.black2};
  img{
    width: 100%;
  }
`;

export const HomeBanner = ({ imgSrc, onClick }: HomeBannerProps) => {
  return (
    <HomeBannerStyle onClick={onClick}>
      <img src={imgSrc} alt="Banner-Home" />
    </HomeBannerStyle>
  );
};
