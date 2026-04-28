namespace areyesram
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public Node()
        {
            Data = default!;
        }

        public Node(T data)
        {
            Data = data;
        }
    }
}