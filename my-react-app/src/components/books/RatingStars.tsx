interface Props {
    rating: number
}


export default function RatingStars({ rating }: { rating: number }) {
    return (
    <div className="stars">
        {'★'.repeat(rating)}
        {'☆'.repeat(5 - rating)}
    </div>
    )
}